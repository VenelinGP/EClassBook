export class Course {
    Id: number;
    Name: string;
    UserId: number;
    TeacherName: string;

    constructor(name: string, userId: number, id?: number, teacherName?: string) {
        this.Id = id;
        this.Name = name;
        this.UserId = userId;
        this.TeacherName = teacherName;
    }
}