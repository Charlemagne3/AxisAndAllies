/**
 * @overview  api server
 * @requires  hapi
 * @requires  hoek
 * @requires  path
 * @requires  vision
 * @requires  handlebars
 */

'use strict';

const Hapi = require('hapi');
const Boom = require('boom');
const Hoek = require('hoek');
const Path = require('path');
const Vision = require('vision');
const Handlebars = require('handlebars');

const routes  = require('./routes');
const jwtAuth = require('./lib/jwt-auth');
const config  = require('./config/environment');

const connection = { port: config.get('port') || 8081 };
const jwtKey = config.get('jwtKey');

const server = new Hapi.Server();

server.connection(connection);

// Register jwtAuth as the auth plugin
server.register(jwtAuth, err => {
  if (err) {
    throw err;
  } else {
    // Register jwt auth as the auth strategy
    server.auth.strategy('jwt-bearer-auth', 'jwt-bearer-auth', { secret: jwtKey });
    // Register routers
    server.route(routes);
  }
});

// Register views
server.register(Vision, (err) => {
  Hoek.assert(!err, err);

  server.views({
    engines: {
      html: Handlebars
    },
    relativeTo: __dirname,
    path: './templates',
    layout: true,
    layoutPath: Path.join(__dirname, 'templates/layout'),
    context: {
      title: 'A&A Odds'
    }
  });
});

const preResponse = function preResponse(request, reply) {
  const response = request.response;
  if (!response.isBoom) {
    return reply.continue();
  }
  // Replace error with friendly HTML
  const error = response;
  return reply(Boom.boomify(error, { statusCode: error.output.statusCode, message: error.message }));
};

server.ext('onPreResponse', preResponse);

server.start((err) => {
  if (err) {
    throw err;
  }
  console.info(`Server running at: ${server.info.uri}`);
});
