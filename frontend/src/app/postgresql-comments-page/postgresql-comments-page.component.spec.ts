import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostgresqlCommentsPageComponent } from './postgresql-comments-page.component';

describe('CommentsPageComponent', () => {
  let component: PostgresqlCommentsPageComponent;
  let fixture: ComponentFixture<PostgresqlCommentsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PostgresqlCommentsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostgresqlCommentsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
