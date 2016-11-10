"use strict";
class Course {
    constructor(name, userId, id, teacherName) {
        this.Id = id;
        this.Name = name;
        this.UserId = userId;
        this.TeacherName = teacherName;
    }
}
exports.Course = Course;
