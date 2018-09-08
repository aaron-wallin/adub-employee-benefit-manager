import { EmployeeBenefitManagerPage } from './app.po';

describe('employee-benefit-manager App', () => {
  let page: EmployeeBenefitManagerPage;

  beforeEach(() => {
    page = new EmployeeBenefitManagerPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('ebm works!');
  });
});
