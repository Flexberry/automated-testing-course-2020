import { moduleForComponent, test } from 'ember-qunit';
import hbs from 'htmlbars-inline-precompile';

moduleForComponent('add-comment', 'Integration | Component | add comment', {
  integration: true
});

test('it renders and works', function(assert) {
  this.set('save', (comment) => {
    assert.deepEqual(comment, { author: 'Jon', text: 'Ok!' });
  });

  this.render(hbs`{{add-comment save=(action save)}}`);

  this.$('input').val('Jon').change();
  this.$('textarea').val('Ok!').change();

  this.$('button').click();
});
