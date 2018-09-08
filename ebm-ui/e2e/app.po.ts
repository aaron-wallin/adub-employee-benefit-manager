import { browser, element, by } from 'protractor';

export class EmployeeBenefitManagerPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(by.css('ebm-root h1')).getText();
  }
}
