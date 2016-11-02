"use strict";
const router_1 = require('@angular/router');
const home_component_1 = require('./components/home.component');
const user_component_1 = require('./components/user.component');
//import { AlbumsComponent } from './components/teachers.component';
//import { AlbumPhotosComponent } from './components/students.component';
//import { accountRoutes, accountRouting } from './components/account/routes';
const appRoutes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: home_component_1.HomeComponent
    },
    {
        path: 'user',
        component: user_component_1.UserComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
