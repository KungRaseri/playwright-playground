import { test, expect } from '@playwright/test';

test('A/B Testing - with `codegen`', async ({ page }) => {
  await page.goto('http://the-internet.herokuapp.com/');
  await page.getByRole('link', { name: 'A/B Testing' }).click();

  await expect(page.getByRole('heading')).toContainText("A/B Test");
  await expect(page.getByRole('paragraph')).toContainText('Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).');
});