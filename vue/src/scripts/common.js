import Enum from "./enum";
import Resource from "./resource";

class CommonJS {
    static Language = Resource.VI.LANGUAGE;

    /**
     * Định dạng dữ liệu
     * @param {String} value Dữ liệu muốn định dạng
     * @param {String} dataType kiểu dữ liệu
     * @return {String} Dữ liệu đã được định dạng
     * Author youngbachhh (22/08/23)
     * */
    static formatData(value, formatType) {
        let language = Resource[CommonJS.Language];
        switch (formatType) {
            case Enum.FORMAT_TYPE.DATE:
                if (value != null) {
                    //value != null && value != undefined && value != ""
                    value = new Date(value);
                    //Lấy ra ngày
                    let day = value.getDate();
                    day = day < 10 ? `0${day}` : day;
                    //Lấy ra tháng + 1 vì tháng trong JS tính từ 0
                    let month = value.getMonth() + 1;
                    month = month < 10 ? `0${month}` : month;
                    //Lấy ra năm
                    let year = value.getFullYear();
                    //Định dạng ngày tháng năm
                    value = `${day}/${month}/${year}`;
                }
                break;

            case Enum.FORMAT_TYPE.GENDER:
                if (value != null) {
                    switch (value) {
                        case Enum.GENDER.MALE:
                            value = language.GENDER.MALE;
                            break;
                        case Enum.GENDER.FEMALE:
                            value = language.GENDER.FEMALE;
                            break;
                        case Enum.GENDER.OTHER:
                            value = language.GENDER.OTHER;
                            break;
                        default:
                            break;
                    }
                }
                break;
            default:
                break;
        }
        if (value == null || value == undefined) {
            value = "";
        }
        return value;
    }


}

export default CommonJS;
