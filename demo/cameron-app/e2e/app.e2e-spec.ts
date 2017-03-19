import { CameronAppPage } from './app.po';

describe('cameron-app App', () => {
  let page: CameronAppPage;

  beforeEach(() => {
    page = new CameronAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
