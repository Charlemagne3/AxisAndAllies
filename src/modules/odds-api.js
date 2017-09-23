/**
 * @overview  OddsApi
 * @module    odds-api
 */

'use strict';

const Joi  = require('joi');

class OddsApi {
  constructor(config) {
    this.landSchema = config.landSchema;
    this.seaSchema = config.seaSchema;
    this.airSchema = config.airSchema;
  }

  /**
   * Returns a promise to be fulfilled with the result
   * @param  {object} data - Describes the battle
   * @return {Promise} a promise to be fulfilled with the result
   */
  getOdds(data) {
    if (!Object.keys(data).length) {
      return Promise.reject(new Error('Empty payload is not allowed'));
    }
    return Promise.resolve(data);
  }
}

module.exports = OddsApi;
