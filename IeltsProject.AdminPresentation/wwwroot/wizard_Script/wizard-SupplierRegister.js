"use strict";

// Class definition
var KTWizard1 = function () {
	

	var _initWizard = function () {
		// Initialize form wizard
		_wizardObj = new KTWizard(_wizardEl, {
			startStep: 1, // initial active step number
			clickableSteps: false  // allow step clicking
		});

		// Validation before going to next page
		_wizardObj.on('change', function (wizard) {
			if (wizard.getStep() > wizard.getNewStep()) {
				return; // Skip if stepped back
			}

			// Validate form before change wizard step
			var validator = _validations[wizard.getStep() - 1]; // get validator for currnt step

			if (validator) {
				validator.validate().then(function (status) {
					if (status == 'Valid') {
						wizard.goTo(wizard.getNewStep());

						KTUtil.scrollTop();
					} else {
						Swal.fire({
							text: "لطفا خطاها را برطرف و دوباره امتحان کنید.",
							icon: "error",
							buttonsStyling: false,
							confirmButtonText: "با خطا روبرو شده اید.",
							customClass: {
								confirmButton: "btn font-weight-bold btn-light"
							}
						}).then(function () {
							KTUtil.scrollTop();
						});
					}
				});
			}

			return false;  // Do not change wizard step, further action will be handled by he validator
		});

		// Change event
		_wizardObj.on('changed', function (wizard) {
			KTUtil.scrollTop();
		});

		// Submit event
		_wizardObj.on('submit', function (wizard) {
			//var t = $("#kt_form").serialize();
			jQuery.ajax({
				type: "POST",
				url: "/SupplierRegister/SupplierLoadRegisterForm",
				//contentType: 'application/json;charset=utf-8',
				//data: JSON.stringify($("#kt_form").serialize()),
				data: $("#kt_form").serialize(),
				success: function (data) {
					if (data.resualt === "success") {
						Swal.fire({
							text: "با تشکر از ثبت نام شما، برای تکمیل پرفایل به صفحه کاربری مراجعه فرمایید.",
							icon: "success",
							buttonsStyling: false,
							confirmButtonText: "با موفقیت ثبت شد.", //+ data.password,
							customClass: {
								confirmButton: "btn font-weight-bold btn-light"
							}
						}).then(function () {
							KTUtil.scrollTop();
						});
					}
					else {
						Swal.fire({
							text: data.message,
							icon: "error",
							buttonsStyling: false,
							confirmButtonText: "با خطا روبرو شده اید.",
							customClass: {
								confirmButton: "btn font-weight-bold btn-light"
							}
						}).then(function () {
							KTUtil.scrollTop();
						});
					}
				},
				error() {
					Swal.fire({
						text: "لطفا خطاها را برطرف و دوباره امتحان کنید.",
						icon: "error",
						buttonsStyling: false,
						confirmButtonText: "با خطا روبرو شده اید.",
						customClass: {
							confirmButton: "btn font-weight-bold btn-light"
						}
					}).then(function () {
						KTUtil.scrollTop();
					});
				}
			});

			//Swal.fire({
			//	text: "All is good! Please confirm the form submission.",
			//	icon: "success",
			//	showCancelButton: true,
			//	buttonsStyling: false,
			//	confirmButtonText: "Yes, submit!",
			//	cancelButtonText: "No, cancel",
			//	customClass: {
			//		confirmButton: "btn font-weight-bold btn-primary",
			//		cancelButton: "btn font-weight-bold btn-default"
			//	}
			//}).then(function (result) {
			//	if (result.value) {
			//		//_formEl.submit(); // Submit form					
			//	} else if (result.dismiss === 'cancel') {
			//		Swal.fire({
			//			text: "Your form has not been submitted!.",
			//			icon: "error",
			//			buttonsStyling: false,
			//			confirmButtonText: "Ok, got it!",
			//			customClass: {
			//				confirmButton: "btn font-weight-bold btn-primary",
			//			}
			//		});
			//	}
			//});
		});
	}

	return {
		// public functions
		init: function () {
			_wizardEl = KTUtil.getById('kt_wizard');
			_formEl = KTUtil.getById('kt_form');

			_initValidation();
			_initWizard();
		}
	};
}();

jQuery(document).ready(function () {
	KTWizard1.init();
});
