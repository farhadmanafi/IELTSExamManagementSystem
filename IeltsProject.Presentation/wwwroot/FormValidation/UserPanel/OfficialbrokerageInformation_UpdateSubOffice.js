// Class definition
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		FormValidation.formValidation(
			document.getElementById('_OfficialbrokerageInformation_UpdateSubOffice'),
			{
				fields: {
					'personalInformationDto.FirstName': {
						validators: {
							notEmpty: {
								message: 'FirstName is required.'
							},
							regexp: {
								regexp: /^[\u0600-\u06FF\s]+$/,  //فقط فارسی                //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'نام باید فارسی باشد'
							}
						}
					},
					SubOfficeName: {
						validators: {
							notEmpty: {
								message: 'نام شعبه اجباری می باشد.'
							},
							regexp: {
								regexp: /^[\u0600-\u06FF\s]+$/,  //فقط فارسی                //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'نام شعبه باید فارسی باشد'
							}
						}
					},
					'personalInformationDto.LastName': {
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
					'personalInformationDto.GenderId': {
						validators: {
							notEmpty: {
								message: 'جنسیت اجباری می باشد.'
							}
						}
					},
					'personalInformationDto.NationalCode': {
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
					'personalInformationDto.MobileNumber': {
						validators: {
							notEmpty: {
								message: 'شمار موبایل اجباری می باشد.'
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
					'contactsInformationDto.PhoneNumber': {
						validators: {
							notEmpty: {
								message: 'شماره تماس اجباری می باشد.'
							},
							regexp: {
								regexp: /^[0-9]+$/,  //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'شماره تماس باید عدد باشد'
							},
							stringLength: {
								max: 11,
								message: 'شماره تماس حداکثر 11 رقم می باشد'
							}
						}
					},
					'personalInformationDto.UniversityDegreeTypeId': {
						validators: {
							notEmpty: {
								message: 'مدرک دانشگاهی اجباری می باشد'
							}
						}
					},
					'personalInformationDto.UniversityDegreeId': {
						validators: {
							notEmpty: {
								message: 'مدرک دانشگاهی اجباری می باشد'
							}
						}
					},
					'personalInformationDto.StudyField': {
						validators: {
							notEmpty: {
								message: 'رشته دانشگاهی اجباری می باشد.'
							}
						}
					},
					'personalInformationDto.StudyFieldId': {
						validators: {
							notEmpty: {
								message: 'رشته دانشگاهی اجباری می باشد.'
							}
						}
					},
					//'personalInformationDto.BirthdayDatePersian': {
					//	validators: {
					//		notEmpty: {
					//			message: 'تاریخ تولد اجباری می باشد.'
					//		}
					//	}
					//},
					'contactsInformationDto.Adress': {
						validators: {
							notEmpty: {
								message: 'آدرس اجباری می باشد.'
							},
							stringLength: {
								max: 100,
								message: 'طول آدرس باید کمتر از 100 کاراکتر باشد'
							}
						}
					},
					'contactsInformationDto.WebSiteAddress': {
						validators: {
							notEmpty: {
								message: 'آدرس وب سایت اجباری می باشد.'
							},
							regexp: {
								regexp: /^((https|http|ftp|smtp):\/\/)(www.)?[a-z0-9]+(\.[a-z]{2,}){1,3}(#?\/?[a-zA-Z0-9#]+)*\/?(\?[a-zA-Z0-9-_]+=[a-zA-Z0-9-%]+&?)?$/,  //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'فرمت وب سایت صحیح نمی باشد'
							}
						}
					},
					'contactsInformationDto.PostalCode': {
						validators: {
							notEmpty: {
								message: 'کد پستی اجباری می باشد.'
							},
							regexp: {
								regexp: /^[0-9]+$/,  //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'کد پستی باید عدد باشد'
							},
							stringLength: {
								max: 10,
								min: 10,
								message: 'کد پستی باید 10 رقم باشد'
							}
						}
					},
					'contactsInformationDto.StateId': {
						validators: {
							notEmpty: {
								message: 'استان اجباری می باشد.'
							}
						}
					},
					'contactsInformationDto.CityId': {
						validators: {
							notEmpty: {
								message: 'شهر اجباری می باشد.'
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
			_initDemo1();
		}
	};
}();

jQuery(document).ready(function () {
	KTFormControls.init();
});
