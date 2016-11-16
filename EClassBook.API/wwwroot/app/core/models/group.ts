export class Group {
    Id: number;
    Name: string;

    constructor(name: string, id?: number) {
        this.Id = id;
        this.Name = name;
    }
}