import { test, expect } from '@playwright/test';

test('test', async ({ page }) => {
  await page.goto('http://the-internet.herokuapp.com/');
  await page.getByRole('link', { name: 'Add/Remove Elements' }).click();
  await page.getByRole('button', { name: 'Add Element' }).click();
  await page.getByRole('button', { name: 'Add Element' }).click();
  await page.getByRole('button', { name: 'Add Element' }).click();
  await page.getByRole('button', { name: 'Delete' }).nth(1).click();

  expect(page.locator('#elements > button')).toHaveCount(2)
});