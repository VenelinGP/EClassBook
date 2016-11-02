import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { UserComponent } from './components/user.component';
//import { AlbumsComponent } from './components/teachers.component';
//import { AlbumPhotosComponent } from './components/students.component';
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
        path: 'user',
        component: UserComponent
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);