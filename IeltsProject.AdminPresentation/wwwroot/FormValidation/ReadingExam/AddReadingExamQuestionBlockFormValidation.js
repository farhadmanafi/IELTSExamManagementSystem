// Class definition
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		FormValidation.formValidation(
			document.getElementById('AddReadingExamQuestionBlockFormValidation'),
			{
				fields: {
					Title: {
						validators: {
							notEmpty: {
								message: 'عنوان اجباری می باشد.'
							}
						}
					},
					StartQuestionNumber: {
						validators: {
							notEmpty: {
								message: 'شماره سوال ابتدای بلوک اجباری می باشد.'
							}
						}
					},
					OrderNo: {
						validators: {
							notEmpty: {
								message: 'ترتیب اجباری می باشد.'
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
