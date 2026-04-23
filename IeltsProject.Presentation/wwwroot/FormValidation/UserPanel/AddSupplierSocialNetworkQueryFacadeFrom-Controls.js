// Class definition
var UpdateContactsInformationFormControls = function () {
	// Private functions
	var _initUpdateContactsInformation = function () {
		FormValidation.formValidation(
			document.getElementById('_UpdateAcademyInformation'),
			{
				fields: {
					TrainingLicenseTypeId: {
						validators: {
							notEmpty: {
								message: 'نوع مجوز اجباری می باشد.'
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
