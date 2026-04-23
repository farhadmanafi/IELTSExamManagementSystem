// Class definition
var UpdateContactsInformationFormControls = function () {
	// Private functions
	var _initUpdateContactsInformation = function () {
		FormValidation.formValidation(
			document.getElementById('_UpdateCompanyInformation_Academy'),
			{
				fields: {
					Name: {
						validators: {
							notEmpty: {
								message: 'نام شرکت اجباری می باشد.'
							},
							regexp: {
								regexp: /^[\u0600-\u06FF\s]+$/,  //فقط فارسی                //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'نام شرکت باید فارسی باشد'
							}
						}
					},
					CompanyTypeId: {
						validators: {
							notEmpty: {
								message: 'نوع شرکت اجباری می باشد.'
							}
						}
					},
					RegistrationNumber: {
						validators: {
							notEmpty: {
								message: 'شماره ثبت اجباری می باشد.'
							}
						}
					},
					NationalNumber: {
						validators: {
							notEmpty: {
								message: 'شناسه ملی اجباری می باشد.'
							}
						}
					},
					Economiccode: {
						validators: {
							notEmpty: {
								message: 'کد اقتصادی اجباری می باشد.'
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
			_initUpdateContactsInformation();
		}
	};
}();

jQuery(document).ready(function () {
	UpdateContactsInformationFormControls.init();
});
