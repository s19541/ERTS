import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import { MatchClient, MatchDto } from "../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import GameList from "./GameList";
import MatchInfo from "./MatchInfo";

interface IProps { }

interface IPassedProps {
	matchId: string;
	gameType: string;
}

interface IState {
	matchId: number;
	match: MatchDto | null;
	gameType: string
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class MatchStats extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			matchId: Number(props.match.params.matchId),
			match: null,
			gameType: props.match.params.gameType
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<MatchDto | null> = {
			action: () => new MatchClient().getMatch(this.state.matchId),
			onSuccess: (response) => {
				this.setState({
					match: response,
				});
			},
		};

		SendActionWithResponse(actionParameters);
	}

	render() {
		return (
			<Container
				style={{
					paddingBottom: "10vh",
					paddingTop: "5vh",
				}}
			>
				<MatchInfo match={this.state.match} gameType={this.state.gameType} />
				<GameList gameList={this.state.match?.games} />
			</Container>
		);
	}
}
export default withRouter(MatchStats);
