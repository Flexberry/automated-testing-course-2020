import Ember from 'ember';
import { moduleForComponent, test } from 'ember-qunit';
import hbs from 'htmlbars-inline-precompile';
import wait from 'ember-test-helpers/wait';

const DataStub = Ember.Service.extend({
  getAll() {
    return new Ember.RSVP.Promise((resolve) => {
      Ember.run.later(resolve, ['Item 1.', 'Item 2.'], 1000);
    });
  },
});

moduleForComponent('data-list', 'Integration | Component | data list', {
  integration: true,
  beforeEach() {
    this.register('service:data', DataStub);
  }
});

test('dat-list', function(assert) {
  this.render(hbs`{{data-list}}`);

  this.$('button').click();

  return wait().then(() => {
    assert.equal(this.$('p:first').text(), 'Item 1.');
    assert.equal(this.$('p:last').text(), 'Item 2.');
  });
});
