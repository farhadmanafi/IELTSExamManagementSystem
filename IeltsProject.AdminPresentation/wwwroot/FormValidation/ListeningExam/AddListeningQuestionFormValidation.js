// Class definition
var KTFormControls = function () {
	// Private functions
	var _initDemo1 = function () {
		FormValidation.formValidation(
			document.getElementById('AddListeningQuestionFormValidation'),
			{
				fields: {
					Title: {
						validators: {
							notEmpty: {
								message: 'عنوان اجباری می باشد.'
							}
						}
					},
					Description: {
						validators: {
							notEmpty: {
								message: 'توضیح اجباری می باشد.'
							}
						}
					},
					OrderNo: {
						validators: {
							notEmpty: {
								message: 'شماره ردیف سوال اجباری می باشد.'
							}
						}
					},
					ListeningQuestionTypeId: {
						validators: {
							notEmpty: {
								message: 'نوع سوال اجباری می باشد.'
							}
						}
					},
					ListeningExamSectionId: {
						validators: {
							notEmpty: {
								message: 'انتخاب بخش اجباری می باشد.'
							}
						}
					},
					ListeningExamQuestionBlockId: {
						validators: {
							notEmpty: {
								message: 'انتخاب بلوک اجباری می باشد.'
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
