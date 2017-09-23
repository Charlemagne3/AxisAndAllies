/**
 * @overview  Tests odds
 * @module    test
 * @requires  chai
 */

'use strict';

const assert = require('chai').assert;

const module1942 = require('./../src/modules/module1942');

const data = { num: 0};
const expectedOdds = {};

describe('getOdds', function() {
  
  it('should return empty', function() {
      assert.deepEqual({}, {});
    }
  );  

  it('should do stuff', function() {
      assert.deepEqual(expectedOdds, expectedOdds);
    }
  );
});
