/**
 * @overview A simple JWT Bearer auth [hapi] plugin
 * @module   jwt-auth
 * @requires environment
 * @requires jsonwebtoken
 */

'use strict';

const Boom = require('boom');
const jwt  = require('jsonwebtoken');

const config  = require('../config/environment');

const jwtKey = config.get('jwtKey');
const audiences  = config.get('audiences');

if (!jwtKey) {
    throw new Error('No private key found for verifying JWTs');
}

if (!audiences) {
    throw new Error('No audience(s) specified for verifying JWTs');
}

const verifyOptions = {
  algorithms : ['HS256'],
  audience   : audiences.split(','),
  issuer     : 'odds',
  subject    : 'odds'
};

function jwtAuth(server, options, next) {
  const plugin = (server, options) => {
    return {
      authenticate: (request, reply) => {
        const authorization = request.headers.authorization;

        if (!authorization || ! /^Bearer.*\w/.test(authorization)) {
          return reply(Boom.badRequest('Invalid HTTP `Authentication` header format', 'Bearer'));
        }

        const accessToken = authorization.split(/\s+/)[1];

        jwt.verify(accessToken, options.secret, verifyOptions, (err, token) => {
          if (err) {
            reply(Boom.unauthorized('Invalid token', 'Bearer'), null, { credentials: token });
          } else {
            reply.continue({ credentials: token });
          }
        });
      }
    };
  };

  server.auth.scheme('jwt-bearer-auth', plugin);
  next();
}

jwtAuth.attributes = {
  name: 'jwt-bearer-auth'
};

module.exports = jwtAuth;
