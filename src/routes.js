/**
 * @overview  Routes
 * @module    routes
 * @requires  joi
 */

'use strict';

const Joi  = require('joi');
const Boom  = require('boom');

const module1942  = require('./modules/module1942');

module.exports = [
  // Get health check
  {
    method: 'GET',
    path: '/health',
    handler: (request, reply) => {
      reply();
    }
  },
  // Post odds data
  {
    method: 'POST',
    path: '/1942',
    config: {
      auth: 'jwt-bearer-auth',
      validate: {
        payload: Joi.alternatives().try(module1942.landSchema, module1942.seaSchema)
      }
    },
    handler: (request, reply) => {
      module1942.getOdds(request.payload)
        .then(result => {
          const response = { results: result, statusCode: 200, message: 'message' };
          reply(response);
        })
        .catch(error => {
          const boom = Boom.wrap(error, 500);
          boom.output.payload.error = error.message;
          reply(boom);
        });
    }
  }
];
