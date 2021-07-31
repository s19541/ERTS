import React from "react";
import { Container, Row, Col, Image } from "react-bootstrap";
import {
	LeagueClient,
	LeagueImageDto,
} from "../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../_infrastructure/actions/SendAction";
import LolLeagueListItem from "./LolLeagueListItem";

interface IState {
	leagues: LeagueImageDto[] | null;
}

class LolLeagueList extends React.Component<any, IState> {
	constructor(props: any) {
		super(props);

		this.state = {
			leagues: null,
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<LeagueImageDto[] | null> = {
			action: () => new LeagueClient().getLeagueImages(),
			onSuccess: (response) => {
				this.setState({
					leagues: response,
				});
			},
		};

		SendActionWithResponse(actionParameters);
	}

	render() {
		return (
			this.state.leagues && (
				<Container style={{ paddingBottom: "10vh", paddingTop: "5vh" }}>
					{this.state.leagues.map((league, i) => (
						<span style={{ padding: "2vh" }} key={league.id}>
							<LolLeagueListItem
								leagueImg={league.imageUrl}
								leagueId={league.id}
							/>
						</span>
					))}
				</Container>
			)
		);
	}
}
export default LolLeagueList;
