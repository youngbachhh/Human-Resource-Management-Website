import CommonJS from "./common";
import Enum from "./enum";
import Resource from "./resource";

var language = Resource[CommonJS.Language];

const Default = {
    // Default value
    Employee: {
        FullName: null,
        DateOfBirth: "1970-01-01",
        Gender: 0,
        Email: null,
        PhoneNumber: null,
        DepartmentId: null,
        PositionId: null,
        PositionName: null,
        DepartmentName: null,
        IdentityNumber: null,
        IdentityDate: "1970-01-01",
        IdentityPlace: null,
        JoinDate: "1970-01-01",
        WorkStatus: null,
        PersonalTaxCode: null,
        Salary: null,
    },
    Gender: [
        { Name: language.GENDER.FEMALE, Value: Enum.GENDER.FEMALE },
        { Name: language.GENDER.MALE, Value: Enum.GENDER.MALE },
        { Name: language.GENDER.OTHER, Value: Enum.GENDER.OTHER },
    ],
    Filter: {
        PageSize: 10,
        Page: 1,
        TotalPage: 3,
        Search: "",
        DepartmentId: null,
        PositionId: null,
    },
};

export default Default;
