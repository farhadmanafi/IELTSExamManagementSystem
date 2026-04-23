// Class definition
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		FormValidation.formValidation(
			document.getElementById('RegistrationFormValidation'),
			{
				fields: {
					FirstName: {
						validators: {
							notEmpty: {
								message: 'First Name Is Required.'
							}
						}
					},
					LastName: {
						validators: {
							notEmpty: {
								message: 'Last Name Is Required.'
							}
						}
					},
					Birthday: {
						validators: {
							notEmpty: {
								message: 'Birth Date Is Required.'
							}
						}
					},
					MobileNumber: {
						validators: {
							notEmpty: {
								message: 'Mobile Number Is Required.'
							}
						}
					},
					NationalCode: {
						validators: {
							notEmpty: {
								message: 'NationalCode Is Required.'
							}
						}
					},
					Address: {
						validators: {
							notEmpty: {
								message: 'Address Is Required.'
							}
						}
					},
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




//********************* Farsi Version ***********************
//	// Class definition
//var KTFormControls = function () {
//	// Private functions
//	var _initDemo1 = function () {
//		FormValidation.formValidation(
//			document.getElementById('RegistrationFormValidation'),
//			{
//				fields: {
//					FirstName: {
//						validators: {
//							notEmpty: {
//								message: 'نام اجباری می باشد.'
//							}
//						}
//					},
//					LastName: {
//						validators: {
//							notEmpty: {
//								message: 'نام خانوادگی اجباری می باشد.'
//							}
//						}
//					},
//					Birthday: {
//						validators: {
//							notEmpty: {
//								message: 'تاریخ تولد اجباری می باشد.'
//							}
//						}
//					},
//					MobileNumber: {
//						validators: {
//							notEmpty: {
//								message: 'شماره موبایل اجباری می باشد.'
//							}
//						}
//					},
//					NationalCode: {
//						validators: {
//							notEmpty: {
//								message: 'کد ملی اجباری می باشد.'
//							}
//						}
//					},
//					Address: {
//						validators: {
//							notEmpty: {
//								message: 'آدرس اجباری می باشد.'
//							}
//						}
//					},
//				},

//				plugins: { //Learn more: https://formvalidation.io/guide/plugins
//					trigger: new FormValidation.plugins.Trigger(),
//					// Bootstrap Framework Integration
//					bootstrap: new FormValidation.plugins.Bootstrap(),
//					// Validate fields when clicking the Submit button
//					submitButton: new FormValidation.plugins.SubmitButton(),
//					// Submit the form when all fields are valid
//					defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
//				}
//			}
//		);
//	}

//	return {
//		// public functions
//		init: function () {
//			_initDemo1();
//		}
//	};
//}();

//jQuery(document).ready(function () {
//	KTFormControls.init();
//});

