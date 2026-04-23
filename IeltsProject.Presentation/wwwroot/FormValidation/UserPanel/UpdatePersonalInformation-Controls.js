// Class definition
var UpdatePersonalInformationFormControls = function () {
	// Private functions
	var _initUpdatePersonalInformation = function () {
		FormValidation.formValidation(
			document.getElementById('_UpdatePersonalInformationQueryFacadeForm'),
			{
				fields: {
					FirstName: {
						validators: {
							notEmpty: {
								message: 'نام اجباری می باشد.'
							},
							regexp: {
								regexp: /^[\u0600-\u06FF\s]+$/,  //فقط فارسی                //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'نام باید فارسی باشد'
							}
						}
					},
					LastName: {
						validators: {
							notEmpty: {
								message: 'نام خانوادگی اجباری می باشد.'
							},
							regexp: {
								regexp: /^[\u0600-\u06FF\s]+$/,  //فقط فارسی                //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'نام خانوادگی باید فارسی باشد'
							}
						}
					},
					GenderId: {
						validators: {
							notEmpty: {
								message: 'جنسیت اجباری می باشد.'
							}
						}
					},
					NationalCode: {
						validators: {
							notEmpty: {
								message: 'کد ملی اجباری می باشد.'
							},
							regexp: {
								regexp: /^[0-9]+$/,  //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'کد ملی باید عدد باشد'
							},
							stringLength: {
								max: 10,
								min: 10,
								message: 'کد ملی باید 10 رقم باشد'
							}
						}
					},
					MobileNumber: {
						validators: {
							notEmpty: {
								message: 'شماره موبایل می باشد.'
							},
							regexp: {
								regexp: /[\u06F0,0]{1}[\u06F9,9]{1}[\u06F0-\u06F9,0-9]{9}/,// /^[0-9]+$/,   //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'شماره باید بصورت 09129999999 وارد گردد'
							},
							stringLength: {
								max: 11,
								min: 11,
								message: 'شمار موبایل باید 11 رقم باشد'
							}
						}
					},
					BirthDayDatePersian: {
						validators: {
							notEmpty: {
								message: 'تاریخ تولد می باشد.'
							}
						}
					},
					UniversityDegreeId: {
						validators: {
							notEmpty: {
								message: 'آخرین مدرک دانشگاهی اجباری می باشد.'
							}
						}
					},
					StudyFieldId: {
						validators: {
							notEmpty: {
								message: 'رشته تحصیلی اجباری می باشد.'
							}
						}
					}
				},

				plugins: { //Learn more: https://formvalidation.io/guide/plugins
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap(),
					// Validate fields when clicking the Submit button
					submitButton: new FormValidation.plugins.SubmitButton(),
					// Submit the form when all fields are valid
					defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
				}
			}
		);
	}

	return {
		// public functions
		init: function () {
			_initUpdatePersonalInformation();
		}
	};
}();

jQuery(document).ready(function () {
	UpdateContactsInformationFormControls.init();
});
