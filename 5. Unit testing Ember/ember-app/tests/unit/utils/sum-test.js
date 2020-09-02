import sum from 'ember-app/utils/sum';
import { module, test } from 'qunit';

module('Unit | Utility | sum');

test('2 + 2 = 4', function(assert) {
  let result = sum(2, 2);
  assert.equal(result, 4);
});

test('0 + 0 = 0', function(assert) {
  let result = sum(0, 0);
  assert.strictEqual(result, 0);
});

test('0 + 0 = 0, with delay 1', function(assert) {
  return sum(0, 0, 1000).then((result) => {
    assert.strictEqual(result, 0);
  });
});

test('0 + 0 = 0, with delay 2', function(assert) {
  const done = assert.async();
  sum(0, 0, 1000).then((result) => {
    assert.strictEqual(result, 0);
    done();
  });
});

test('0 + 0 = 0, with delay 3', function(assert) {
  const done = assert.async();
  sum(0, 0, 1000).then((result) => {
    assert.strictEqual(result, 0);
  }).finally(done);
});
