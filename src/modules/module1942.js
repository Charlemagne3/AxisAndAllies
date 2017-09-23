/**
 * @overview  1942 module
 * @module    1942
 * @requires  joi
 */

'use strict';

const OddsApi = require('./odds-api');
const Joi  = require('joi');

const config = {
  landSchema: {
    attackers: {
      infantry: Joi.number(),
      artillery: Joi.number(),
      tanks: Joi.number(),
      fighters: Joi.number(),
      strategic_bombers: Joi.number()
    },
    defenders: {
      infantry: Joi.number(),
      artillery: Joi.number(),
      tanks: Joi.number(),
      fighters: Joi.number(),
      strategic_bombers: Joi.number(),
      anti_aircraft_artillery: Joi.number()
    }
  },
  seaSchema: {
    attackers: {
      submarines: Joi.number(),
      destroyers: Joi.number(),
      cruisers: Joi.number(),
      battleships: Joi.number(),
      aircraft_carriers: Joi.number(),
      fighters: Joi.number(),
      strategic_bombers: Joi.number()
    },
    defenders: {
      submarines: Joi.number(),
      destroyers: Joi.number(),
      cruisers: Joi.number(),
      battleships: Joi.number(),
      aircraft_carriers: Joi.number(),
      fighters: Joi.number()
    }
  },
  airSchema: {
    attackers: {
      fighters: Joi.number(),
      strategic_bombers: Joi.number()
    },
    defenders: {
      fighters: Joi.number()
    }
  },
};

module.exports = new OddsApi(config);
