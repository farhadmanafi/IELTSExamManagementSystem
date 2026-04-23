// Class definition
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		FormValidation.formValidation(
			document.getElementById('AddWritingExamSectionFormValidation'),
			{
				fields: {
					Title: {
						validators: {
							notEmpty: {
								message: 'عنوان اجباری می باشد.'
							}
						}
					},
					TimerMinuties: {
						validators: {
							notEmpty: {
								message: 'زمان اجباری می باشد.'
							},
							regexp: {
								regexp: /^[1-9][0-9]?$|^100$/,
								message: 'زمان باید عددی بین 1 و100 باشد'
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
