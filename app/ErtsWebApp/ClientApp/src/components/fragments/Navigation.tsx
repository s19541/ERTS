import React from "react";
import { Navbar } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";

class Navigation extends React.Component<RouteComponentProps> {
	private redirectToPage(page: string) {
		this.props.history.push(page);
	}

	render() {
		return (
			<>
				<Navbar bg="dark" variant="dark" sticky="top">
					<Navbar.Brand style={{ marginLeft: 10 }}>
						<img
							onClick={() => this.redirectToPage("/")}
							alt=""
							src="/images/erts-logo-simple.png"
							width="100"
							height="35"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
				</Navbar>
			</>
		);
	}
}
export default withRouter(Navigation);
