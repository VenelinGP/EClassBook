import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { TeachersComponent } from './components/teachers.component';
import { TeacherCoursesComponent } from './components/teacher-courses.component';
import { AllCoursesComponent } from './components/all-courses.component';
import { AllGroupComponent } from './components/all-group.component';


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
    },
    {
        path: 'courses',
        component: AllCoursesComponent
    },
    {
        path: 'group',
        component: AllGroupComponent
    }

];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);