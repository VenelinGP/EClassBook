"use strict";
const router_1 = require('@angular/router');
const account_component_1 = require('./account.component');
const login_component_1 = require('./login.component');
const register_component_1 = require('./register.component');
exports.accountRoutes = [
    {
        path: 'account',
        component: account_component_1.AccountComponent,
        children: [
            { path: 'register', component: register_component_1.RegisterComponent },
            { path: 'login', component: login_component_1.LoginComponent }
        ]
    }
];
exports.accountRouting = router_1.RouterModule.forChild(exports.accountRoutes);
