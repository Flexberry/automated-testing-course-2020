import Ember from 'ember';
import { moduleForModel, test } from 'ember-qunit';

moduleForModel('author', 'Unit | Model | author', {
  // Specify the other units that are required for this test.
  needs: []
});

test('it exists', function(assert) {
  let model = this.subject();
  assert.ok(!!model);
});

test('fullName test', function(assert) {
  let model = this.subject({ name: 'Jon', surname: 'Smit' });
  assert.equal(model.get('fullName'), 'Jon Smit', 'fullName true');

  Ember.run(() => {
    model.set('name', 'Jo');
  });

  assert.equal(model.get('fullName'), 'Jo Smit', 'fullName change true');
});
