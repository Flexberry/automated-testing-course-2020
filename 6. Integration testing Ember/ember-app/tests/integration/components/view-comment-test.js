import { moduleForComponent, test } from 'ember-qunit';
import hbs from 'htmlbars-inline-precompile';

moduleForComponent('view-comment', 'Integration | Component | view comment', {
  integration: true
});

test('it renders', function(assert) {
  this.set('comment', { author: 'Jon', text: 'Ok!' });

  this.render(hbs`{{view-comment comment=comment}}`);

  assert.equal(this.$('h1').text(), 'Jon');
  assert.equal(this.$('p').text(), 'Ok!');
});
