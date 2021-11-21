import React from "react";
import { Navbar, NavDropdown, Image, Container, Nav } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import i18n from "../../i18n";
import { withTranslation } from "react-i18next";

interface IState {
	language: string;
}

class Navigation extends React.Component<RouteComponentProps, IState> {

	constructor(props: RouteComponentProps) {
		super(props);

		this.state = {
			language: i18n.language
		};
	}

	private redirectToPage(page: string) {
		this.props.history.push(page);
	}

	handleLanguageChange = (language: any) => {
		this.setState({
			language: language
		});
		i18n.changeLanguage(language, (err, t) => {
			if (err) return console.log("something went wrong loading", err);
		});
	};

	render() {
		const t = i18n.t
		return (
			<>
				<Navbar bg="dark" variant="dark" sticky="top">
					<Container fluid>
						<Navbar.Brand>
							<img
								onClick={() => this.redirectToPage("/")}
								alt=""
								src="/images/erts-logo-simple.png"
								width="100"
								height="35"
								className="d-inline-block align-top"
							/>{" "}
						</Navbar.Brand>
						<Navbar.Collapse id="navbar-dark-example" className="justify-content-end">
							<Nav>
								<NavDropdown
									id="nav-dropdown"
									title={
										<Image src={`/images/flags/${this.state.language.toUpperCase()}.png`}
											width={25}
											height={25} />
									}
									align="end"
									menuVariant="dark"
								>
									<NavDropdown.Item onClick={() => {
										this.handleLanguageChange("us");
									}}>
										<Image src={`/images/flags/US.png`}
											width={25}
											height={25} />
										{" "}{t("languages.us")}
									</NavDropdown.Item>
									<NavDropdown.Item onClick={() => {
										this.handleLanguageChange("pl");
									}}>
										<Image src={`/images/flags/PL.png`}
											width={25}
											height={25} />
										{" "}{t("languages.pl")}
									</NavDropdown.Item>
								</NavDropdown>
							</Nav>
						</Navbar.Collapse>
					</Container>
				</Navbar>
			</>
		);
	}
}
export default withTranslation()(withRouter(Navigation));
