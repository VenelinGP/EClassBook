export class Teacher {
    Id: number;
    Username: string;
    FirstName: string;
    LastName: string;
    AddressId: number;
    RoleID: number;

    constructor(id: number,
        username: string,
        firstName: string,
        lastName: string,
        addressId: number,
        roleID: number) {
        this.Id = id;
        this.Username = username;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.AddressId = addressId;
        this.RoleID = roleID;
    }
}