"use strict";
const router_1 = require('@angular/router');
const home_component_1 = require('./components/home.component');
const teachers_component_1 = require('./components/teachers.component');
const teacher_courses_component_1 = require('./components/teacher-courses.component');
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
        path: 'teacher',
        component: teachers_component_1.TeachersComponent
    },
    {
        path: 'teacher/:id',
        component: teacher_courses_component_1.TeacherCoursesComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
