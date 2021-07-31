export const SendAction = (parameters: IActionParameters<void>) => {
	parameters
		.action()
		.then(() => parameters.onSuccess && parameters.onSuccess())
		.catch(() => parameters.onFailure && parameters.onFailure());
};

const openNotification = (title: string, message: string) => {
	console.log(`Powiadomienie: ${title}\n${message}`);
};

const openErrorNotification = (title: string, message: string) => {
	console.log(`Powiadomienie - Błąd: ${title}\n${message}`);
};

export const SendActionWithResponse = <TResponse>(
	parameters: IActionParameters<TResponse>
) => {
	const failureTitle = "Nieoczekiwany błąd";
	const failureMessage =
		"Wystąpił nieoczekiwany błąd. Skonsultuj się z Administratorem";

	parameters
		.action()
		.then((response) => parameters.onSuccess && parameters.onSuccess(response))

		.catch(() => {
			openErrorNotification(failureTitle, failureMessage);
			parameters.onFailure && parameters.onFailure();
		});
};

export const SendActionWithResponseAndNotification = <TResponse>(
	parameters: IActionParametersWithNotification<TResponse>
) => {
	const failureTitle = parameters.failureTitle
		? parameters.failureTitle
		: "Nieoczekiwany błąd";
	const failureMessage = parameters.failureMessage
		? parameters.failureMessage
		: "Wystąpił nieoczekiwany błąd. Skonsultuj się z Administratorem";

	parameters
		.action()
		.then((response) => {
			openNotification(parameters.successTitle, parameters.successMessage);
			parameters.onSuccess && parameters.onSuccess(response);
		})
		.catch(() => {
			openErrorNotification(failureTitle, failureMessage);
			parameters.onFailure && parameters.onFailure();
		});
};

export interface IActionParameters<TResponse> {
	action: () => Promise<TResponse>;
	onSuccess?: (response: TResponse) => void;
	onFailure?: () => void;
}

export interface IActionParametersWithNotification<TResponse>
	extends IActionParameters<TResponse> {
	successTitle: string;
	successMessage: string;
	failureTitle?: string;
	failureMessage?: string;
}
