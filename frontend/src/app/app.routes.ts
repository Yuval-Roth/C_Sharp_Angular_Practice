import { Routes } from '@angular/router';
import {PostgresqlCommentsPageComponent} from './postgresql-comments-page/postgresql-comments-page.component';
import {MongoCommentsPageComponent} from './mongo-comments-page/mongo-comments-page.component';

export const routes: Routes = [
  {
    path: 'postgresql',
    component: PostgresqlCommentsPageComponent
  },
  {
    path: 'mongo',
    component: MongoCommentsPageComponent
  }
];
