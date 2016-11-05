"use strict";
class Teacher {
    constructor(id, username, firstName, lastName, addressId, roleID) {
        this.Id = id;
        this.Username = username;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.AddressId = addressId;
        this.RoleID = roleID;
    }
}
exports.Teacher = Teacher;
