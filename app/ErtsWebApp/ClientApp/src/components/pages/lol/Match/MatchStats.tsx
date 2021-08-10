import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import {
	GameClient,
	LolGameStatsDto,
	MatchClient,
	MatchDto,
} from "../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import GameList from "./GameList";
import MatchInfo from "./MatchInfo";

interface IProps {}

interface IPassedProps {
	matchId: string;
}

interface IState {
	matchId: number;
	match: MatchDto | null;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class LolTournamentMatchList extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			matchId: Number(props.match.params.matchId),
			match: null,
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
				<MatchInfo match={this.state.match} />
				<GameList gameList={this.state.match?.games} />
			</Container>
		);
	}
}
export default withRouter(LolTournamentMatchList);