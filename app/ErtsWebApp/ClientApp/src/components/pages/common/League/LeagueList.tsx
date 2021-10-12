import React from "react";
import { Container, Row, Col, Image } from "react-bootstrap";
import {
	LeagueClient,
	LeagueImageDto,
} from "../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import LeagueListItem from "./LeagueListItem";
import { RouteComponentProps } from "react-router-dom";

interface IProps { }

interface IPassedProps {
	gameType: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

interface IState {
	leagues: LeagueImageDto[] | null;
	gameType: string;
}

class LeagueList extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			leagues: null,
			gameType: props.match.params.gameType
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<LeagueImageDto[] | null> = {
			action: () => new LeagueClient().getLeagueImages(this.state.gameType),
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
							<LeagueListItem
								gameType={this.state.gameType}
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
export default LeagueList;
