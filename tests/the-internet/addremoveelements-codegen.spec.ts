import { test, expect } from '@playwright/test';

test('Add/Remove Elements', async ({ page }) => {
  await page.goto('http://the-internet.herokuapp.com/');
  await page.getByRole('link', { name: 'Add/Remove Elements' }).click();
  await page.getByRole('button', { name: 'Add Element' }).click();
  await page.getByRole('button', { name: 'Add Element' }).click();
  await page.getByRole('button', { name: 'Add Element' }).click();
  await page.getByRole('button', { name: 'Delete' }).nth(1).click();

  expect(page.getByRole('button', {name: 'Delete'})).toHaveCount(2);
});