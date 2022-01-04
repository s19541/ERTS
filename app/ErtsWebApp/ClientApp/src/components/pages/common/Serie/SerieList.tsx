import React from "react";
import { Container, Row, Col, Image } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import {
	LeagueClient,
	LeagueDto,
	SerieClient,
	SerieShortDto,
} from "../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import SerieListTable from "./SerieListTable";

interface IProps { }

interface IPassedProps {
	leagueId: string;
}

interface IState {
	leagueId: number;
	series: SerieShortDto[] | null;
	league: LeagueDto | null;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class SerieList extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			leagueId: Number(props.match.params.leagueId),
			series: null,
			league: null,
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<SerieShortDto[] | null> = {
			action: () =>
				new SerieClient().getSeriesShort(this.state.leagueId),
			onSuccess: (response) => {
				this.setState({
					series: response,
				});
			},
		};

		SendActionWithResponse(actionParameters);

		let actionParameters2: IActionParameters<LeagueDto | null> = {
			action: () => new LeagueClient().getLeague(this.state.leagueId),
			onSuccess: (response) => {
				this.setState({
					league: response,
				});
			},
		};

		SendActionWithResponse(actionParameters2);
	}

	render() {
		return (
			<Container style={{ paddingBottom: "10vh", paddingTop: "5vh" }}>
				<Row className="align-items-center">
					<Col md="2">
						<Image src={this.state.league?.imageUrl} fluid />
					</Col>
					<Col md="2">
						<p className="h1 text-white">{this.state.league?.name}</p>
						<p>
							<a href={this.state.league?.url} className="h3 text-white">
								{this.state.league?.url}
							</a>
						</p>
					</Col>
				</Row>
				<SerieListTable
					serieList={this.state.series}
					leagueId={this.state.leagueId}
				/>
			</Container>
		);
	}
}
export default withRouter(SerieList);
