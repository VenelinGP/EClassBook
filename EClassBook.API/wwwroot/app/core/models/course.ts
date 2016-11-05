export class Course {
    Id: number;
    Name: string;
    UserId: string;
    TeacherName: string;

    constructor(id: number,
        name: string,
        userId: string,
        user: string) {
        this.Id = id;
        this.Name = name;
        this.UserId = userId;
        this.TeacherName = user;
    }
}