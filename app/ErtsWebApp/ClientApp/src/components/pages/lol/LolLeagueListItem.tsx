import { Container, Row, Col, Image } from "react-bootstrap";

function LolLeagueListItem(props: { leagueImg: any; leagueId: number }) {
	var leagueImg = props.leagueImg;
	var leagueId = props.leagueId;
	return (
		<a href={`lol/${leagueId}`}>
			<Image src={leagueImg} rounded />
		</a>
	);
}

export default LolLeagueListItem;
