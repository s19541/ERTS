import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../../css/myStyle.css";
import { MatchClient, MatchShortDto } from "../../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../../_infrastructure/actions/SendAction";
import LolMatchListTable from "./TournamentMatchListTable";
import TournamentNav from "../TournamentNav";

interface IProps { }

interface IPassedProps {
	gameType: string;
	tournamentId: string;
}

interface IState {
	gameType: string;
	tournamentId: number;
	matchList: MatchShortDto[] | null;
	key: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class TournamentMatchList extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			gameType: props.match.params.gameType,
			tournamentId: Number(props.match.params.tournamentId),
			matchList: null,
			key: "matches",
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<MatchShortDto[] | null> = {
			action: () => new MatchClient().getMatches(this.state.tournamentId),
			onSuccess: (response) => {
				this.setState({
					matchList: response,
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
				<TournamentNav activeKey={this.state.key} gameType={this.state.gameType} />
				<LolMatchListTable matchList={this.state.matchList} gameType={this.state.gameType} />
			</Container>
		);
	}
}
export default withRouter(TournamentMatchList);
