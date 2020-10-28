<%@ Page Title="Frequently asked Questions" Language="C#" MasterPageFile="~/HomePage.master" AutoEventWireup="true" CodeFile="FAQs.aspx.cs" Inherits="FAQs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Breadcrumbs -->
    <div class="breadcrumbs">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <ul>
                        <li class="home"><a href="Index.aspx" title="Go to Home Page">Home</a> <span>/</span> </li>
                        <li><strong>FAQs</strong> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumbs End -->
    <!-- main-container -->
    <div class="main-container col2-right-layout">
        <div class="main container">
            <div class="row">
                <section class="col-sm-12">
                    <div class="col-main">
                        <div class="page-title">
                            <h2>Frequently Asked Questions</h2>
                        </div>
                        <div class="static-contain">
                            <div class="panel-body">
                                <div class="panel-group" id="accordion">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">How can I change my shipping address?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse in">
                                            <div class="panel-body">
                                                We do not store your shipping address;So, there's nothing to worry about it. You can just write your address what you want and where you want your product get delivered;but, make sure it should be correct.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">How do I activate my account?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseTwo" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                The instructions to activate your account will be sent to your email once you have submitted the registration form. If you did not receive this email, your email service provider’s mailing software may be blocking it. You can try checking your junk / spam folder or contact us at help@mirrorofbrands.com
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">How can I track my orders & payment?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseThree" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                You can track your order after placing means, after confirmation you'll receive an email that your order is been processed and in that email you'll find the name of courier company along with the tracking ID where you can track your package and stay in contact with them.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour">How do I cancel my orders if I want?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseFour" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                You can cancel your order by going into your "My Account" page where in Order History you can cancel your Order. but, you've to make sure that its not been processed or out for delivery.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive">How long will it take for my order to arrive after I make payment?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseFive" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                Members who ship their orders with BlueDart, FedEx, DTDC should expect to receive their orders within three (3) to five (5) working days upon payment verification depending on the volume of orders received.
                                                If you experience delays in receiving your order, contact us immediately and we will help to confirm the status of your order.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix">What is the accumulated delivery fee for? How much is the handling fee?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseSix" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                There are two Delivery Option, (i) is "Free Delivery" in which Delivery charge is not applicable and (ii) is 2 Day Delivery in which Delivery charge is Rs. 250. Handling fee is covered in delivery charge.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">How do you ship my orders?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseSeven" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                All your Orders are sent via BlueDart, FedEx, DTDC courier comapnies.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseEight">What are the payment methods available?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseEight" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                At the moment, we accept "Cash On Delivery" and Wallet Payments Like "Paytm".
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseNine">Why must I make payment immediately at checkout?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseNine" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                Ordering is on ‘first-come-first-served’ basis. To ensure that you get your desired product, it is recommended that you make your payment within 60 minutes of checking out.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTen">What happens if there's been a delivery mishap to my order? (Damaged or lost delivery)</a>
                                            </h4>
                                        </div>
                                        <div id="collapseTen" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                We take such matters very seriously and will look into individual cases thoroughly. Any products that falls under the below categories should not be thrown away before taking video proof and emailing the video of the affected product and your D.O (Delivery Order) to us at help@mirrorofbrands.com (if applicable).<br />
                                                We regret to inform you that no refunds will be given for orders that fall under the below categories.<br />
                                                1. In the event of damaged products received, we will require video proof of the affected product and your D.O (Delivery Order) in order for us to investigate and review before a decision is made to re-send the sample to you at no cost, subject to availability. In light of this, any product that falls into this category should not be thrown away before taking photo proof and emailing the photo to us at help@mirrorofbrands.com<br />
                                                2. In the event of lost mail, we will try to locate the delivery team in courier company and if there's a clear indication that your order is indeed lost, we'll re-send the order to you at no cost, subject to availability.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseEleven">What happens in the event of unsatisfactory/expired/wrong sample/missing samples?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseEleven" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                We take such matters very seriously and will look into individual cases thoroughly. Any product that falls under the below categories should not be thrown away before taking photo proof and emailing the photo of the affected product and your D.O (Delivery Order) to us at help@mirrorofbrands.com (if applicable).<br />
                                                We regret to inform you that no refunds will be given for orders that fall under the below categories.<br />
                                                1. In the event that the product you've received is unsatisfactory in any way you perceive, we will require photo proof of the sample and your D.O (Delivery Order) as well and you may be required to send us back the product for close inspection and review before a decision is made to re-send a sample to you at no cost, subject to availability. The postage cost will be on your own when you deliver the product to us.<br />
                                                2. In the event that you receive an expired product, we will require clear photo proof of the product and its expiry date for close inspection and review before a decision is made to re-send a product to you at no cost, subject to availability.<br />
                                                3. In the event that you've received the wrong product, we will require photo proof of the wrongly sent product and D.O (Delivery Order) and after reviewing, we'll re-send the correct product to you at no cost, subject to availability.<br />
                                                4. In the event you've received your order with a missing product, we will require you to email us a clear photo proof of your D.O (Delivery Order) to help@mirrorofbrands.com and after which, kindly give us a call at (+91) 9725201308 and our customer service officer will attend to you to find out more before a decision is made to re-send the missing product to you at no cost, subject to availability.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwelve">I am having problems accessing Website. Some of the pages look weird. Am I using the right browser?</a>
                                            </h4>
                                        </div>
                                        <div id="collapseTwelve" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                As our website uses some of the latest graphics designs which may not be supported in lower version of browsers, it is recommended that you use the following browsers to access our website:<br />
                                                1. Microsoft Internet Explorer Version 10 or higher version.<br />
                                                2. Mozilla Firefox Version 10 or higher version.<br />
                                                3. Google Chrome Version 12 or higher version.<br />
                                                <br />
                                                In addition, please ensure that your Javascript and Cookie is enabled on your browser.
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- .panel-body -->
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <!--End main-container -->
</asp:Content>

