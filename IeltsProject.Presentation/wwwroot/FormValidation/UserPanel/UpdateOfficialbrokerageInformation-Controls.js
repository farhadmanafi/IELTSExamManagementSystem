// Class definition
var UpdateContactsInformationFormControls = function () {
	// Private functions
	var _initUpdateContactsInformation = function () {
		FormValidation.formValidation(
			document.getElementById('_UpdateOfficialbrokerageInformation'),
			{
				fields: {
					OfficialbrokerageName: {
						validators: {
							notEmpty: {
								message: 'نام دفتر کارگزاری اجباری می باشد.'
							},
							regexp: {
								regexp: /^[\u0600-\u06FF\s]+$/,  //فقط فارسی                //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'نام دفتر کارگزاری باید فارسی باشد'
							}
						}
					},
					OfficialbrokerageCode: {
						validators: {
							notEmpty: {
								message: 'کد دفتر کارگزاری اجباری می باشد.'
							}
						}
					},
					LicenseValidityDatePersian: {
						validators: {
							notEmpty: {
								message: 'تاریخ اعتبار پروانه اجباری می باشد.'
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
