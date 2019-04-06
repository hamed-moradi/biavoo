using System;
using System.Collections.Generic;
using System.Text;

namespace shared.utility {
    public class GeneralMessage {
        public const string ExceptionSource = "Custom";
        public const string OK = "عملیات با موفقیت انجام شد.";
        public const string InternalServerError = "عملیات با خطا مواجه شد.";
        public const string TokenNotFound = "شناسه یافت نشد";
        public const string DataOwnerKeyNotFound = "حوزه شناسایی نشد";
        public const string DataOwnerCenterKeyNotFound = "ستاد شناسایی نشد";
        public const string UserIsNotActive = "کاربر فعال نمی باشد";
        public const string PhoneIsNotVerified = "شماره تلفن تایید نشده است";
        public const string ConnectionError = "خطا در برقرای ارتباط.";
        public const string UnexpectedError = "خطا پیش بینی نشده.";
        public const string AppNotFound = "اپلیکیشن یافت نشد.";
        public const string PanelNotFound = "پنل یافت نشد.";
        public const string MessageCountError = "ناهم خوانی تعداد پیام ها با شماره های ارسالی.";
        public const string EmptyId = "موردی انتخاب نشده است.";
        public const string NothingFound = "موردی یافت نشد.";
        public const string DefectiveEntry = "لطفا تمام موارد درخواستی را وارد نمایید";
        public const string retrieveLimit = "رکوردهای بارگذاری شده بیش از میزان مجاز هستند";
    }
}
