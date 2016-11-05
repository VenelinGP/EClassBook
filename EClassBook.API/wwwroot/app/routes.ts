import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { TeachersComponent } from './components/teachers.component';
import { TeacherCoursesComponent } from './components/teacher-courses.component';
import { accountRoutes, accountRouting } from './components/account/routes';


const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'teacher',
        component: TeachersComponent
    },
    {
        path: 'teacher/:id',
        component: TeacherCoursesComponent
    }

];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);