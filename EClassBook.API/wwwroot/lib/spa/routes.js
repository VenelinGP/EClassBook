"use strict";
const router_1 = require('@angular/router');
const home_component_1 = require('./components/home.component');
const teachers_component_1 = require('./components/teachers.component');
const teacher_courses_component_1 = require('./components/teacher-courses.component');
const all_courses_component_1 = require('./components/all-courses.component');
const all_group_component_1 = require('./components/all-group.component');
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
    },
    {
        path: 'courses',
        component: all_courses_component_1.AllCoursesComponent
    },
    {
        path: 'group',
        component: all_group_component_1.AllGroupComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
