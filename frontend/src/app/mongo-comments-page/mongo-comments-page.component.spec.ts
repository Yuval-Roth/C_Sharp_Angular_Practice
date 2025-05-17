import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MongoCommentsPageComponent } from './mongo-comments-page.component';

describe('CommentsPageComponent', () => {
  let component: MongoCommentsPageComponent;
  let fixture: ComponentFixture<MongoCommentsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MongoCommentsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MongoCommentsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
