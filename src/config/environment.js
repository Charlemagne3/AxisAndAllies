/**
 * Sets up environment-specific configuration
 * @module config
 * @requires nconf
 */

'use strict';

const nconf = require('nconf');

const config = nconf
  .argv()
  .env()
  .file(`${__dirname}/environment.json`);

module.exports = config;
